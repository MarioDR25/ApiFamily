namespace ApiFamily;

public class FamilyStructure
{
    public string LastName { get; set; }
    private int NextId = 1;
    private List<Member> Members { get; set; }


    //Constructor
    public FamilyStructure(string lastName)
    {
        LastName = lastName;
        Members =
        [
            new Member("John", 33, [7, 13, 22], lastName, GenerateId()),
            new Member("Jane", 35, [10, 14, 3], lastName, GenerateId()),
            new Member("Jimmy", 5, [1], lastName, GenerateId()),
        ];
    }

    public int GenerateId() => NextId++; //Generar Id
    public List<Member> GetAllMembers() => Members; //Obtener todos los miembros 
    public Member? GetMember(int id) => Members.Find(m => m.Id == id); //Obtener un miembro por id
    public void DeleteMember(int id) => Members.RemoveAll(m => m.Id == id); //Eliminar un miembro
    
    //Agregar nuevo miembro
    public Member AddMember(Member member)
    {
        Member newMember = member with { Id = GenerateId(), LastName = LastName };
        Members.Add(newMember);
        return newMember;
    } 
}

//Tipo de dato para cada miembro de la Familia
public record Member(string FirstName, int Age, List<int> LuckyNumbers, string? LastName = null, int Id = 0);

