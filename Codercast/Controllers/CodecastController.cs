using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA.Data;
using OA.Repo;
using OA.Service;

namespace Codercast
{

    [Route("api/[controller]")]
    [ApiController]
    public class CodecastController : ControllerBase
    {
        private readonly IMapper mapper;
        PresentCodecastUsecase usecase = new PresentCodecastUsecase();

        public CodecastController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public string GetData()
        {
            TestSetup.setupSampleData();
            User mike = Context.userGateway.findUserByName("Bob");
            List<PresentableCodecast> codecasts = usecase.presentCodecast(mike);
           // PresentableCodecastModel[] models = mapper.Map<PresentableCodecastModel[]>(codecasts);
            var results = JsonConvert.SerializeObject(codecasts);
            return results;
            //StringBuilder sb = new StringBuilder();
            //foreach (PresentableCodecast codecast in codecasts)
            //{
            //    sb.Append("Title:" + codecast.title);
            //    sb.Append("Publication Date:" + codecast.publicationDate);
            //    sb.Append("IsDownloadable:" + codecast.isDownloadable);
            //    sb.Append("IsViewable:" + codecast.isViewable);
            //    sb.Append("---------------");

            //}
            //return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv");
        }
    }
}