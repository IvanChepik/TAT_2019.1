using System.Collections.Generic;
using Models;

namespace DataBases
{
    public interface IParsing
    {
        List<Model> GetAll();
    }
}