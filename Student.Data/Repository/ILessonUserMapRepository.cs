﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Data.Entities;
using Student.Data.GenericRepository;

namespace Student.Data.Repository
{
    public interface ILessonUserMapRepository: IGenericRepository<LessonUserMap>
    {

    }
}