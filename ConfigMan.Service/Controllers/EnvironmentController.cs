﻿// using ConfigMan.Data;
// using ConfigMan.Data.Models;
// using ConfigMan.Service.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Data;
//
// namespace ConfigMan.Service.Controllers;
//
// // [Route("api/[controller]")]
// // [ApiController]
// // [Authorize(Roles = "Administrator")]
// // public class EnvironmentSettingsController : ControllerBase
// // {
// //     private readonly IEnvironmentService _environmentService;
// //
// //     public EnvironmentSettingsController(IEnvironmentService environmentService)
// //     {
// //         _environmentService = environmentService;
// //     }
// //
// //     // POST: api/environments
// //     [HttpPost]
// //     public async Task<ActionResult<DeploymentEnvironment>> CreateEnvironmentSetting(List<EnvironmentSetting> settings)
// //     {
// //         foreach (var environmentSetting in settings)
// //         {
// //             var setting = new Setting() { Name = environmentSetting.Name, Value = environmentSetting.Value };
// //             await _environmentService.AddSettingToEnvironment(environmentSetting.Environment, setting);
// //         }
// //         return CreatedAtAction(nameof(CreateEnvironmentSetting), null);
// //     }
// // }
//
// [Route("api/[controller]")]
// [ApiController]
// [Authorize(Roles = "Administrator")]
// public class EnvironmentController
// {
//     private readonly IEnvironmentSetService _environmentService;
//
//     public EnvironmentController(IEnvironmentSetService environmentService)
//     {
//         _environmentService = environmentService;
//     }
//
//     [HttpPost]
//     public async Task<ActionResult<DeploymentEnvironment>> Create()
//     {
//         // var env = await _environmentService.GetOneAsync("");
//         // env.DeploymentEnvironments[0].Name = "JS"
//         return new OkResult();
//     }
// }