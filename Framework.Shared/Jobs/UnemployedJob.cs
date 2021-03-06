namespace Framework.Shared.Jobs;

public class UnemployedJob : BaseJob
{
    public override string Name => "Unemployed";
    public override string Description => "The default job.";

    public override BaseJobGrade[] JobGrades => new BaseJobGrade[]
    {
        new Unemployed( this )
    };

    public class Unemployed : BaseJobGrade
    {
        public override string Name => "Unemployed";
        public override int Salary => 50;

        public Unemployed( BaseJob job ) : base( job ) { }
    }
}