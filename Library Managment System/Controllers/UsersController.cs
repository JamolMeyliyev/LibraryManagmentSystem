using LibraryManagmentSystem.LogicLayer.Models;
using LibraryManagmentSystem.LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserServive _service;
    public UsersController(IUserServive service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] UserFilterModel filter)
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
    public async Task<IActionResult> Create([FromBody] CreateUserModel model)
    {
        try
        {
            return Ok(await _service.CreateAsync(model));
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
            return Ok(await _service.GetReturnAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserModel model)
    {
        try
        {
            return Ok(await _service.UpdateAsync(model));
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
            return Ok(await _service.DeleteAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
   
}
