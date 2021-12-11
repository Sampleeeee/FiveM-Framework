using Framework.Shared.Jobs;

namespace Framework.Shared.Jobs;

public class PoliceJob : BasePoliceJob
{
    public override string Name => "Los Santos Police Department";
    public override string Description => "Protect and Serve";

    public override BaseJobGrade[] JobGrades => new BaseJobGrade[]
    {
        new Chief( this ),
        new AssistantChief( this ),
        new Major( this ),
        new Captain( this ),
        new Lieutenant( this ),
        new Sergeant( this ),
        new OfficerIII( this ),
        new OfficerII( this ),
        new OfficerI( this ),
        new Cadet( this ),
    };

    public class Chief : BaseJobGrade
    {
        public override string Name => "Chief";
        public override int Salary => 500;

        public Chief( BaseJob job ) : base( job ) { }
    }

    public class AssistantChief : BaseJobGrade
    {
        public override string Name => "Assistant Chief";
        public override int Salary => 450;

        public AssistantChief( BaseJob job ) : base( job ) { }
    }

    public class Major : BaseJobGrade
    {
        public override string Name => "Assistant Chief";
        public override int Salary => 400;

        public Major( BaseJob job ) : base( job ) { }
    }

    public class Captain : BaseJobGrade
    {
        public override string Name => "Captain";
        public override int Salary => 350;

        public Captain( BaseJob job ) : base( job ) { }
    }

    public class Lieutenant : BaseJobGrade
    {
        public override string Name => "Lieutenant";
        public override int Salary => 300;

        public Lieutenant( BaseJob job ) : base( job ) { }
    }

    public class Sergeant : BaseJobGrade
    {
        public override string Name => "Sergeant";
        public override int Salary => 250;

        public Sergeant( BaseJob job ) : base( job ) { }
    }

    public class OfficerIII : BaseJobGrade
    {
        public override string Name => "Officer III";
        public override int Salary => 200;

        public OfficerIII( BaseJob job ) : base( job ) { }
    }

    public class OfficerII : BaseJobGrade
    {
        public override string Name => "Officer II";
        public override int Salary => 150;

        public OfficerII( BaseJob job ) : base( job ) { }
    }

public class OfficerI : BaseJobGrade
    {
        public override string Name => "Officer I";
        public override int Salary => 100;

        public OfficerI( BaseJob job ) : base( job ) { }
    }

    public class Cadet : BaseJobGrade
    {
        public override string Name => "Cadet";
        public override int Salary => 50;

        public Cadet( BaseJob job ) : base( job ) { }
    }
}