using FaksistentX.Services.Base;
using FaksistentX.Services.Comments.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Comments
{
    public class CommentAppService : BaseAppService
    {
        public async Task<List<CommentDto>> GetAllAsync(CommentRequestDto input)
        {
            var result = await GetListAsync<CommentDto>("services/app/Comment/GetAll", input);

            return result.Result.Items;
        }
        public async Task<CommentDto> GetAsync(string id)
        {
            var result = await GetAsync<CommentDto>("services/app/Comment/Get", new EntityDto(id));

            return result.Result;
        }

        public async Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            var result = await PostAsync<CommentDto>("services/app/Comment/Create", input);

            return result.Result;
        }
    }
}
