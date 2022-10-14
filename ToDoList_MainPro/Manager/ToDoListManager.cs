using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tazeez.Common.Extensions;
using ToDoList.Helper;
using ToDoList.Models;
using ToDoList.ModelView;
using ToDoList_MainPro.Manager.Interface;
using ToDoList_ModelView.ModelView;

namespace ToDoList_MainPro.Manager
{
    //public class ToDoListManager : IDoList
    //{
        

    //    private IMapper _mapper;
    //    private todolistContext _dbcontext;

    //    public ToDoListManager(todolistContext dbcontext, IMapper mapper)
    //    {
    //        dbcontext = _dbcontext;
    //        _mapper = mapper;
    //    }




    //        public ToDoView Create(ToDoView dolist)
    //        {


    //            var list = _dbcontext.Todos.Add(new Todo
    //            {
    //                Content = dolist.Content,
    //                Image = dolist.Image,

    //            }).Entity;

    //            _dbcontext.SaveChanges();

    //            var res = _mapper.Map<ToDoView>(list);

    //            return res;

    //        }

    //    }

    //    public ToDoView Updatelist(ToDoView currentlist, UpdateList UpList)
    //    {
    //        var list = _dbcontext.Todos.
    //                                .FirstOrDefault(a => a.Id == currentlist.Id)
    //                                ?? throw new ServiceValidationException("List not found");

    //        var url = "";

    //        if (!string.IsNullOrWhiteSpace(UpList.ImageString))
    //        {
    //            url = Helper.SaveImage(UpList.ImageString, "profileimages");
    //        }

    //        Todo.Title = UpList.Title;
    //        Todo.Content = UpList.Content;
    //        Todo.Image = UpList.Image;


    //    if (!string.IsNullOrWhiteSpace(url))
    //        {
    //            var baseURL = "https://localhost:44309/";
    //            Todo.Image = @$"{baseURL}/api/v1/user/fileretrive/profilepic?filename={url}";
    //        }

    //        _dbcontext.SaveChanges();
    //        return _mapper.Map<ToDoView>(Todo);
    //    }


    //    public void DeleteList(ToDoView currentList, int id)
    //    {
    //        if (currentList.Id == id)
    //        {
    //            throw new ServiceValidationException("You have no access to delete your self");
    //        }

    //        var user = _dbcontext.Todos
    //                      .FirstOrDefault(a => a.Id == id)
    //                      ?? throw new ServiceValidationException("list not found");

    //        Todo.Archived = true;
    //        _dbcontext.SaveChanges();
    //    }


    //    public List<ToDoView> Get()
    //    {
    //        return _mapper.Map<List<ToDoView>>(_dbcontext.Todos.ToList());
    //    }


    //    #endregion public
    //}
}
