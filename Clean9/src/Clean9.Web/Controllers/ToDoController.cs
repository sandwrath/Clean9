﻿using Clean9.Core;
using Clean9.Core.Entities;
using Clean9.SharedKernel.Interfaces;
using Clean9.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Clean9.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _repository.ListAsync<ToDoItem>())
                            .Select(ToDoItemDTO.FromToDoItem);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
