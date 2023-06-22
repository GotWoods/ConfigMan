﻿using System.Security.Claims;
using ConfigMan.Data;
using ConfigMan.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfigMan.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Administrator")]
public class ApplicationSettingsController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    private readonly IEnvironmentSetService _environmentService;
    private readonly ILogger<ApplicationSettingsController> _logger;

    public ApplicationSettingsController(IApplicationService applicationService, IEnvironmentSetService environmentService, ILogger<ApplicationSettingsController> logger)
    {
        _applicationService = applicationService;
        _environmentService = environmentService;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "Application")]
    public async Task<ActionResult> Get()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
        {
            _logger.LogWarning("Can not find application @{Claims}", User.Claims);
            return NotFound("Claim not found");
        }

        // var env = await _environmentService.GetOneAsync("Dev");
        // var application = await _applicationService.GetApplicationByIdAsync(claim.Value);
        return Ok(); // application.GetAppliedSettings(env));
    }

    [HttpPost("{application}/{environment}/{variable}")]
    public async Task<ActionResult> CreateNew(string application, string environment, string variable)
    {
        var app = await _applicationService.GetApplicationByIdAsync(application);
        var environmentSet = await _environmentService.GetOneAsync(app.EnvironmentSet);

        if (environment == "Default")
        {
            var setting = new Setting();
            setting.Name = variable;
            app.ApplicationDefaults.Add(setting);
        }
        else
        {
            foreach (var environmentSetting in environmentSet.DeploymentEnvironments)
            {
                var setting = new Setting();
                setting.Name = variable;
                if (!app.EnvironmentSettings.ContainsKey(environmentSetting.Name))
                    app.EnvironmentSettings.Add(environmentSetting.Name, new List<Setting>());
                app.EnvironmentSettings[environmentSetting.Name].Add(setting);
            }
        }

        await _applicationService.UpdateApplicationAsync(app);

        return CreatedAtAction(nameof(CreateNew), null);
    }


    [HttpPut("{application}/{environment}/{variable}")]
    public async Task<ActionResult> Update(string application, string environment, string variable, [FromBody] string value)
    {
        var app = await _applicationService.GetApplicationByIdAsync(application);

        if (environment == "Default")
        {
            app.ApplicationDefaults.First(x => x.Name == variable).Value = value;
        }
        else
        {
            //in case we have duplicates, we clean them up here
            var firstMatch = app.EnvironmentSettings[environment].First(x => x.Name == variable);
            app.EnvironmentSettings[environment].RemoveAll(x => x.Name == variable && x != firstMatch);

            firstMatch.Value = value;
        }

        await _applicationService.UpdateApplicationAsync(app);

        return Ok();
    }

    [HttpPost("{application}/{variable}/rename")]
    public async Task<IActionResult> RenameVariable(string application, string variable, [FromBody] string newName)
    {
        var app = await _applicationService.GetApplicationByIdAsync(application);

        foreach (var environmentSetting in app.EnvironmentSettings)
        foreach (var item in environmentSetting.Value)
            if (item.Name == variable)
                item.Name = newName;

        await _applicationService.UpdateApplicationAsync(app);

        return Ok();
    }
}