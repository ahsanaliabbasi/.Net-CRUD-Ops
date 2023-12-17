using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDBContext dBContext;

        public RegionsController(NZWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        // GET: https://localhost:7082/api/Regions/:id
        [HttpGet]
        public IActionResult GetWalks()
        {

            var Regions = dBContext.Region.ToList();


            var RegionDTO = new List<RegionDTO>();
            foreach (var region in Regions)
            {
                RegionDTO.Add(
                    new RegionDTO()
                    {
                        Id = region.Id,
                        Code = region.Code,
                        Name = region.Name,
                        RegionImageUrl = region.RegionImageUrl

                    }) ;
            }


            return Ok(RegionDTO);
        }


        [HttpGet("{id}")]
        public IActionResult GetRegionById(Guid id)
        {

            // Reciving complete object form DB.
            var Region = dBContext.Region.Find(id);
            if (Region == null) return NotFound();


            // Converting the object to DTO
            var RegionDTO = new RegionDTO();

            RegionDTO.Code = Region.Code;
            RegionDTO.Name = Region.Name;
            RegionDTO.Id = Region.Id;
            RegionDTO.RegionImageUrl= Region.RegionImageUrl;
            

            return Ok(RegionDTO);
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] CreateRegionDTO createRegionDTO) {
            

            // Converting received RTO to a region to save it in DB.
            var Region = new Regions
            {
                Code = createRegionDTO.Code,
                Name = createRegionDTO.Name,
                RegionImageUrl = createRegionDTO.RegionImageUrl
            };

            //  Saving data in DB.
            var flag=dBContext.Region.Add(Region);
            var SavedOrNot = dBContext.SaveChanges();


            // Converting Data into DTO again to return back to user.
            var myRegion = new RegionDTO
            {
                Id = Region.Id,
                Code = Region.Code,
                Name = Region.Name,
                RegionImageUrl = Region.RegionImageUrl,
            };



            return Ok(myRegion);
        
        }


        [HttpPut("{id}")]
        public  IActionResult UpdateRegion(Guid id,[FromBody]  UpdateRegionDTO updateRegionDTO)
        {

            var Region= dBContext.Region.FirstOrDefault(x=>x.Id==id);

            if (Region == null) return NotFound();


            Region.Code= updateRegionDTO.Code;
            Region.Name= updateRegionDTO.Name;
            Region.RegionImageUrl= updateRegionDTO.RegionImageUrl;

            dBContext.SaveChanges();
            return Ok(Region);
        }


        [HttpDelete]
        public IActionResult DeleteRegion(Guid id)
        {
            var fRegion= dBContext.Region.FirstOrDefault(x=>x.Id==id);

            if (fRegion == null) return NotFound();

            var flag=dBContext.Region.Remove(fRegion);
            dBContext.SaveChanges();

            // Returning a DTO back to client

            var mRegionDTO = new RegionDTO
            {
                Id = fRegion.Id,
                Code = fRegion.Code,
                Name = fRegion.Name,
                RegionImageUrl = fRegion.RegionImageUrl,
            };

            return Ok(mRegionDTO);

        }

    }
}
