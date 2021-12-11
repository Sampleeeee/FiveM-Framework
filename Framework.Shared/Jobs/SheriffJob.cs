namespace Framework.Shared.Jobs;

public class SheriffJob : BasePoliceJob
{
    public override string Name => "San Andreas State Troopers";
    public override string Description => "Protect and Serve";

    public override BaseJobGrade[] JobGrades => new BaseJobGrade[]
    {
        new Colonel( this ),
        new LtColonel( this ),
        new Major( this ),
        new Captain( this ),
        new Lieutenant( this ),
        new Sergeant( this ),
        new Corporal( this ),
        new TrooperII( this ),
        new TrooperI( this ),
        new Cadet( this )
    };

    public class Colonel : BaseJobGrade
    {
        public override string Name => "Colonel";
        public override int Salary => 1_000;

        public Colonel( BaseJob job ) : base( job ) { }
    }

    public class LtColonel : BaseJobGrade
    {
        public override string Name => "Lt. Colonel";
        public override int Salary => 900;

        public LtColonel( BaseJob job ) : base( job ) { }
    }

    public class Major : BaseJobGrade
    {
        public override string Name => "Major";
        public override int Salary => 800;

        public Major( BaseJob job ) : base( job ) { }
    }

    public class Captain : BaseJobGrade
    {
        public override string Name => "Captain";
        public override int Salary => 700;

        public Captain( BaseJob job ) : base( job ) { }
    }

    public class Lieutenant : BaseJobGrade
    {
        public override string Name => "Lieutenant";
        public override int Salary => 600;

        public Lieutenant( BaseJob job ) : base( job ) { }
    }

    public class Corporal : BaseJobGrade
    {
        public override string Name => "Corporal";
        public override int Salary => 500;

        public Corporal( BaseJob job ) : base( job ) { }
    }

    public class Sergeant : BaseJobGrade
    {
        public override string Name => "Sergeant";
        public override int Salary => 400;

        public Sergeant( BaseJob job ) : base( job ) { }
    }

    public class TrooperII : BaseJobGrade
    {
        public override string Name => "Trooper II";
        public override int Salary => 300;

        public TrooperII( BaseJob job ) : base( job ) { }
    }

    public class TrooperI : BaseJobGrade
    {
        public override string Name => "Trooper I";
        public override int Salary => 200;

        public TrooperI( BaseJob job ) : base( job ) { }
    }

    public class Cadet : BaseJobGrade
    {
        public override string Name => "Cadet";
        public override int Salary => 100;

        public Cadet( BaseJob job ) : base( job ) { }
    }
}