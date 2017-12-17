using LittleActicFox.Simple.Core.Todo;
using LittleArcticFox.Core;
using LittleArcticFox.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleActicFox.Simple.Application.AppServices
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSimple : MyBaseApplication, IAppSimple
    {
        private readonly IRepository<TodoItem, int> _repository;
        public AppSimple(IRepository<TodoItem, int> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task Add()
        {
            await _repository.InstertAsync(new TodoItem
            {
                Title = "Todo:" + DateTime.Now.ToString("MMss"),
                Content = DateTime.Now.ToString()
            });
        }

        [HttpGet]
        public async Task Del(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
        [HttpGet]
        public async Task<List<TodoItem>> GetItems()
        {
            var result = await _repository.GetAll();
            return result.ToList();
        }

        /// <summary>
        /// 测试用的方法
        /// </summary>
        /// <returns>一个字符串</returns>
        [HttpGet]
        //[Authorize]
        public async Task<string> GetString()
        {
            return await Task.FromResult(ApplicationName);
        }
    }
}
