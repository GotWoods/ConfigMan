﻿using ConfigMan.Data;
using ConfigMan.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigMan.Service.Controllers.MyApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    // GET: api/Applications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
    {
        return Ok(await _applicationService.GetApplicationsAsync());
    }

    // GET: api/Applications/5
    [HttpGet("{name}")]
    public async Task<ActionResult<Application>> GetApplication(string name)
    {
        var application = await _applicationService.GetApplicationByIdAsync(name);

        if (application == null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    // POST: api/Applications
    [HttpPost]
    public async Task<ActionResult<Application>> CreateApplication(Application application)
    {
        await _applicationService.CreateApplicationAsync(application);

        return CreatedAtAction(nameof(GetApplication), new { id = application.Name }, application);
    }

    // DELETE: api/Applications/5
    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteApplication(string name)
    {
        await _applicationService.DeleteApplicationAsync(name);
        return NoContent();
    }
}