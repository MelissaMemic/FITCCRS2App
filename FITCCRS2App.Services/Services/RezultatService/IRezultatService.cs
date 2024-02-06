﻿using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.BaseServices;

namespace FITCCRS2App.Services.Services.RezultatService
{
    public interface IRezultatService : ICRUDService<Rezultat, BaseSearchObject, RezultatUpsertRequest, RezultatUpsertRequest>
    {
    }
}