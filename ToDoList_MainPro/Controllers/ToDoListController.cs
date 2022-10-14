using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDoList.Models;
using ToDoList.ModelView;
using ToDoList_MainPro.Manager.Interface;
using ToDoList_ModelView.ModelView;

namespace ToDoList.Controllers
{
    
    [ApiController]
    public class ToDoListController : ApiBaseController
    {
        //private IDoList _List;
        //private readonly ILogger<ToDoListController> _logger;

        //public UserController(IDoList List,
        //                      ILogger<ToDoListController> logger)
        //{
        //    _logger = logger;
        //    _List = List;
        //}


        //// GET: api/<UserController>
        //[HttpGet]
        //[Route("api/list")]
        //public IActionResult Get()
        //{
        //    var res = _List.Get();
        //    return Ok(res);
        //}




        //[Route("api/list/Create")]
        //[HttpPost]
    
        //public IActionResult Create([FromBody] ToDoView todo)
        //{
        //    var user = _List.Create(todo);
        //    return Ok(user);
        //}




        //[Route("api/user/fileretrive/profilepic")]
        //[HttpGet]
        //public IActionResult Retrive(string filename)
        //{
        //    var folderPath = Directory.GetCurrentDirectory();
        //    folderPath = $@"{folderPath}\{filename}";
        //    var byteArray = System.IO.File.ReadAllBytes(folderPath);
        //    return File(byteArray, "image/jpeg", filename);
        //}

        //// PUT api/<UserController>/5

        //[Route("api/list/Update")]
        //[HttpPut]
    
        //public IActionResult UpdateDoList(UpdateList Up)
        //{
        //    var user = _List.UpdateList(LoggedInUser, Up);
        //    return Ok(user);
        //}


        //[HttpDelete]
        //[Route("api/list/Delete/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _List.DeleteList(LoggedInUser, id);
        //    return Ok();
        //}

    }
}
