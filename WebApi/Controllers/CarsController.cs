﻿using Business.Abstract;
using Business.Concrete;
using Core.Utilities.IoC;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        private IHttpContextAccessor _httpcontextAccessor;

        public CarsController(ICarService carService)
        {
            _carService = carService;
            _httpcontextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbybrandname")]
        public IActionResult GetCarDetailsByBrandName(string brandName)
        {
            var result = _carService.GetCarDetailsByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetCarById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarbydetails")]
        public IActionResult GetCarByDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}