using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Codercast;
using OA.Data;

namespace Codercast 
{
    class PresentableCodecastProfile : Profile
    {
        public PresentableCodecastProfile()
        {
            this.CreateMap<PresentableCodecast, PresentableCodecastModel>();
        }
    }
}
