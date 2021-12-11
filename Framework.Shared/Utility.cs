using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Shared.Items.Bases;
using Framework.Shared.Jobs;

namespace Framework.Shared;

public static class Utility
{
    #region Items
    
    private static readonly List<BaseItem> _itemCache = new();

    public static IEnumerable<BaseItem> GetAllItems()
    {
        if ( _itemCache.Count != 0 ) return _itemCache;

        IEnumerable<Type> types = typeof( BaseItem )
            .Assembly
            .GetTypes()
            .Where( x => x.IsClass && !x.IsAbstract && x.IsSubclassOf( typeof( BaseItem ) ) );

        foreach ( var type in types )
            if ( Activator.CreateInstance( type ) is BaseItem i )
                _itemCache.Add( i );

        return _itemCache;
    }

    public static BaseItem GetItem( string uniqueId ) =>
        GetAllItems().FirstOrDefault( x => x.UniqueId == uniqueId );
    
    #endregion
    #region Jobs

    private static readonly List<BaseJob> _jobCache = new();

    public static IEnumerable<BaseJob> GetAllJobs()
    {
        if ( _jobCache.Count != 0 ) return _jobCache;

        IEnumerable<Type> types = typeof( BaseJob )
            .Assembly
            .GetTypes()
            .Where( x => x.IsClass && !x.IsAbstract && x.IsSubclassOf( typeof( BaseJob ) ) );

        foreach ( var type in types )
            if ( Activator.CreateInstance( type ) is BaseJob j )
                _jobCache.Add( j );

        return _jobCache;
    }

    public static BaseJob GetJob( string uniqueId ) =>
        GetAllJobs().FirstOrDefault( x => x.UniqueId == uniqueId );
    
    #endregion
    #region Job Grades

    private static readonly List<BaseJobGrade> _jobGradeCache = new();

    public static IEnumerable<BaseJobGrade> GetAllJobGrades()
    {
        if ( _jobGradeCache.Count != 0 ) return _jobGradeCache;

        IEnumerable<Type> types = typeof( BaseJobGrade )
            .Assembly
            .GetTypes()
            .Where( x => x.IsClass && !x.IsAbstract && x.IsSubclassOf( typeof( BaseJobGrade ) ) );

        foreach ( var type in types )
            if ( Activator.CreateInstance( type ) is BaseJobGrade j )
                _jobGradeCache.Add( j );

        return _jobGradeCache;
    }

    public static BaseJobGrade GetJobGrade( string uniqueId ) =>
        GetAllJobGrades().FirstOrDefault( x => x.UniqueId == uniqueId );

    #endregion
}