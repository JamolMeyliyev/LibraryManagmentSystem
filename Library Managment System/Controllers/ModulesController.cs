using LibraryManagmentSystem.LogicLayer.Models;
using LibraryManagmentSystem.LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{

    private readonly IModuleService _service;
    public ModulesController(IModuleService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] FilterModuleListModel filter)
    {
        try
        {
            return Ok(await _service.GetListAsync(filter));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateModuleModel model)
    {
        try
        {
            return Ok(await _service.CreateModelAsync(model));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            return Ok(await _service.GetReturnModuleAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateModuleModel model,long id)
    {
        try
        {
            return Ok(await _service.UpdateModelAsync(model,id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            return Ok(await _service.DeleteModelAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}
