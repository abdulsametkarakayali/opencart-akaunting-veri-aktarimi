using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

/// <summary>
/// Summary description for Veritabani
/// </summary>
public class Veritabani
{
    protected MuhasebeEntities _entity;
    protected MuhasebeEntities Entity
    {
        get
        {
            if (_entity == null)
                _entity = new MuhasebeEntities();
            return _entity;
        }
    }

    protected Opencart _opencartentity; 
    protected Opencart OpencartEntity
    {
        get
        {
            if (_opencartentity == null)
                _opencartentity = new Opencart();
            return _opencartentity;
        }
    }

}