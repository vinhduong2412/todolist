﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Todo.DTOs;

namespace Todo.Services
{
    public class TaskService : ITaskService
    {
        private readonly DataAccessContext _context;
        private readonly IMapper _mapper;
        public TaskService(DataAccessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddTodoTaskAsync(todoTaskDTO model)
        {
            var newTask = _mapper.Map<todoTask>(model);
            _context.todoTasks!.Add(newTask);
            await _context.SaveChangesAsync();

            return newTask.Id;
        }

        public async Task DeleteTodoTaskAsync(int id)
        {
            var deleteTask = _context.todoTasks!.SingleOrDefault(t => t.Id == id);
            if(deleteTask != null)
            {
                _context.todoTasks!.Remove(deleteTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<todoTaskDTO>> GetAllTodoTasksAsync()
        {
            var task = await _context.todoTasks!.ToListAsync();
            return _mapper.Map<List<todoTaskDTO>>(task);
        }

        public async Task<todoTaskDTO> GetTodoTasksAsync(int id)
        {
            var task = await _context.todoTasks!.FindAsync(id);
            return _mapper.Map<todoTaskDTO>(task);
        }

        public async Task UpdateTodoTaskAsync(int id, todoTaskDTO model)
        {
            if(id == model.Id)
            {
                var updateTask = _mapper.Map<todoTask>(model);
                _context.todoTasks!.Update(updateTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}