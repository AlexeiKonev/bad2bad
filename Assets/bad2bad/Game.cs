using UnityEngine;
/// <summary>
/// класс для сохранения данных
/// </summary>
public class Saver
{

    private object _object;
    public Saver(object obj)
    {
        _object = obj;
    }
    public void SaveData()
    {

    }
}
/// <summary>
/// обьект для загрузки сохранений
/// </summary>
public class Loader
{
    private object _object;
    public Loader(object obj)
    {
        _object = obj;
    }
    public void LoadData()
    {

    }
}
/// <summary>
/// флаги для выбора оружия
/// </summary>
public enum GunFlag
{
    Pistol,
    AK47
}
/// <summary>
/// Базовый  класс оружия
/// </summary>
public class Gun
{
    public string Name { get; set; }
    public int MaxAmmo { get; set; }
    public int CurrentAmmo { get; set; }
}
public class Pistol : Gun
{
    public Pistol(int maxAmmo)
    {
        Name = "Pistol";
        MaxAmmo = maxAmmo;
        CurrentAmmo = MaxAmmo;
    }
}
public class Automat : Gun
{
    public Automat(int maxAmmo)
    {
        Name = "AK47";
        MaxAmmo = maxAmmo;
        CurrentAmmo = MaxAmmo;
    }
}
/// <summary>
/// класс игрока содержит инфу о положении в пространстве
/// </summary>
public class Player
{


    public float posX = 0;
    public float posY = 0;
    public float posZ = 0;

    Gun _gun;

    public void SelectNextGun(GunFlag gunChoosen)
    {
        if (gunChoosen == GunFlag.Pistol)
        {
            _gun = new Pistol(10);
        }
        if (gunChoosen == GunFlag.AK47)
        {
            _gun = new Automat(32);
        }
    }
    public void Shoot()
    {
        Debug.Log($"выстрел из {_gun.Name}");
    }
    public void GunReload()
    {
        Debug.Log($"перезарядка   {_gun.Name}");
    }
}
/// <summary>
/// Главный класс игры
/// </summary>
public class Game : MonoBehaviour
{
    Saver _objectSaver;

    Loader _objectLoader;

    Player _player;
    public Transform playerTransform;
    public GunFlag _gunChoosen;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        _player = new Player();
        _objectSaver = new Saver((object)_player);
    }

    void PositionUpdate()
    {
        _player.posX = playerTransform.position.x;

        _player.posY = playerTransform.position.y;

        _player.posZ = playerTransform.position.z;

        Debug.Log($"posX{_player.posX} posY{_player.posY} posZ{_player.posZ}");
    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerTransform.Translate(Vector2.right * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerTransform.Translate(Vector2.left * Time.deltaTime);
        } 
        if (Input.GetAxis("Vertical") > 0)
        {
            playerTransform.Translate(Vector2.up * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            playerTransform.Translate(Vector2.down * Time.deltaTime);
        }
    

    


        if (Input.GetKey(KeyCode.F12))
        {
            PositionUpdate();
            Debug.Log("save");
        }

        if (Input.GetKey(KeyCode.F11))
        {

            Debug.Log("load");
        }
    }
}

