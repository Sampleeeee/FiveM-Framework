namespace Framework.Shared.Jobs;

public abstract class BaseJob
{
    public string UniqueId => GetType().FullName;
    
    public abstract string Name { get; }
    public abstract string Description { get; }
    
    public abstract BaseJobGrade[] JobGrades { get; }
}

public abstract class BaseJobGrade
{
    public string UniqueId => GetType().FullName;
    public string JobId { get; set; }
    
    public abstract string Name { get; }
    public abstract int Salary { get; }

    public BaseJobGrade( BaseJob job )
    {
        JobId = job.GetType().FullName;
    }
}