﻿using ApiPlayground.Models;
using ApiPlayground.Models.Dto;

namespace ApiPlayground.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name ="Pool View"},
            new VillaDTO { Id = 2, Name ="Beach View"}
        };
    }
}
