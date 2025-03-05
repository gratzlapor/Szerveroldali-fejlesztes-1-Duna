using Microsoft.AspNetCore.Mvc;
using Duna.Data;
using Duna.Entities.Entity;
using Duna.Entities.Dto;

namespace Duna.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DunaController
    {
        DunaContext ctx;

        public DunaController(DunaContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<DunaGetDto> GetDunaAdat()
        {
            //return ctx.DunaAdatok.Select(x => new DunaGetDto
            //{
            //    Date = x.Date.ToString().Substring(0, 10),
            //    Value = x.Value
            //});

            return ctx.DunaAdatok.GroupBy(x => new { x.Date.Year, x.Date.Month}).Select(y=> new DunaGetDto 
            { 
                Date = y.Key.Year.ToString() + "." + y.Key.Month.ToString(),
                MaxValue = y.Max(x=> x.Value),
                MinValue = y.Min(x => x.Value),
                AvgValue = y.Average(x=> x.Value)

            });


            //var months = ctx.DunaAdatok.Select(date => DateTime.Parse(date.Date)).Select(x => new DunaGetDto
            //{
            //    Date = x.Year + "." + x.Month
            //});

            //return ctx.DunaAdatok.Select(x => new
            //{
            //    Year = DateTime.Parse(x.Date).Year,
            //    Month = DateTime.Parse(x.Date).Month,
            //    Value = x.Value

            //}).GroupBy(y => new { y.Year, y.Month })
            //.Select(g=> new DunaGetDto
            //{
            //    Date= g.Key.Year + "." + g.Key.Month,
            //    Value = g.Sum(x  => x.Value)
            //});


        }

        [HttpPost]
        public void Post(DunaCreateUpdateDto dto)
        {
            var adat = new DunaAdat
            {
                Date = dto.Date,
                Value = dto.Value
            };
            ctx.DunaAdatok.Add(adat);
            ctx.SaveChanges();
        }

    }
}
