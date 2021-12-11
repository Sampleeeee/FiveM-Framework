namespace Framework.Shared.Jobs;

public class PoliceJob : BasePoliceJob
{
    public override string Name => "Los Santos Police Department";
    public override string Description => "Protect and Serve";

    public override BaseJobGrade[] JobGrades => new BaseJobGrade[]
    {
        new Chief(),
        new AssistantChief(),
        new Major(),
        new Captain(),
        new Lieutenant(),
        new Sergeant(),
        new OfficerIII(),
        new OfficerII(),
        new OfficerI(),
        new Cadet(),
    };

    public class Chief : BaseJobGrade
    {
        public override string Name => "Chief";
        public override int Salary => 500;
    }

    public class AssistantChief : BaseJobGrade
    {
        public override string Name => "Assistant Chief";
        public override int Salary => 450;
    }

    public class Major : BaseJobGrade
    {
        public override string Name => "Assistant Chief";
        public override int Salary => 400;
    }

    public class Captain : BaseJobGrade
    {
        public override string Name => "Captain";
        public override int Salary => 350;
    }

    public class Lieutenant : BaseJobGrade
    {
        public override string Name => "Lieutenant";
        public override int Salary => 300;
    }

    public class Sergeant : BaseJobGrade
    {
        public override string Name => "Sergeant";
        public override int Salary => 250;
    }

    public class OfficerIII : BaseJobGrade
    {
        public override string Name => "Officer III";
        public override int Salary => 200;
    }

    public class OfficerII : BaseJobGrade
    {
        public override string Name => "Officer II";
        public override int Salary => 150;
    }

    public class OfficerI : BaseJobGrade
    {
        public override string Name => "Officer I";
        public override int Salary => 100;
    }

    public class Cadet : BaseJobGrade
    {
        public override string Name => "Cadet";
        public override int Salary => 50;
    }
}