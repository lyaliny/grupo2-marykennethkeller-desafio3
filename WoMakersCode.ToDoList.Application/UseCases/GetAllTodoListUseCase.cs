using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases
{
    public class GetAllTodoListUseCase : IUseCaseAsync<string, List<TaskListResponse>>
    {
        private readonly IRepository _todoListRepository;

        public GetAllTodoListUseCase(IRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public Task<List<TaskListResponse>> ExecuteAsync(string request)
        {
            var resposta = _todoListRepository.GetTaskAll().Result;

            var response = resposta.Select(x => new TaskListResponse()
            {
                Id = x.Id,
                ListName = x.ListName,
            });

            return Task.FromResult(response.ToList());
        }
    }
}
