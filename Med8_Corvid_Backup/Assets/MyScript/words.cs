using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class words : MonoBehaviour
{
    List<string> wordPool = new List<string>();
    public Text txt;
    //List<string> writePool = new List<string>();
    bool listEmpty = false;

    private float secondsCount;


    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        int randNr = rand.Next(1,2);
        MakeLists(wordPool, randNr);
        txt = GameObject.Find("Word").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            try
            {
                Timer();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Debug.Log("List is empty!");
                listEmpty = true;
            }
    }
    

    void PickWord(List<string> pool)
    {
        var rand = new System.Random();
        int index = rand.Next(pool.Count);
        string word = pool[index];
        pool.Remove(word);
        txt.text = word;
        //int leng = pool.Count;
        //Debug.Log(leng);
        //Debug.Log(word);
    }

    void MakeLists(List<string> pList, int poolNr)
    {
        if (poolNr == 1)
        {
            pList.Add("Draw Butterfly");
            pList.Add("Draw Pineapple");
            pList.Add("Draw Lion");
            pList.Add("Draw Corn");
            pList.Add("Draw Cat");
            pList.Add("Draw Owl");
            pList.Add("Draw Skirt");
            pList.Add("Draw Frog");
            pList.Add("Draw Doll");
            pList.Add("Draw Balloon");
            pList.Add("Draw Kite");
            pList.Add("Draw Stove");
            pList.Add("Draw Ruler");
            pList.Add("Draw Grapes");
            pList.Add("Draw Door");

            //WRITE UNDER THIS
            pList.Add("Write Harp");
            pList.Add("Write Elephant");
            pList.Add("Write Ear");
            pList.Add("Write Lemon");
            pList.Add("Write Pumpkin");
            pList.Add("Write Mushroom");
            pList.Add("Write Axe");
            pList.Add("Write Violin");
            pList.Add("Write Canon");
            pList.Add("Write Spider");
            pList.Add("Write Wrench");
            pList.Add("Write Lamp");
            pList.Add("Write Pig");
            pList.Add("Write Rooster");
            pList.Add("Write Airplane");
        }

        if (poolNr == 2)
        {
            pList.Add("Draw Glove");
            pList.Add("Draw Sweater");
            pList.Add("Draw Pepper");
            pList.Add("Draw Stool");
            pList.Add("Draw Blouse");
            pList.Add("Draw Screwdriver");
            pList.Add("Draw Pants");
            pList.Add("Draw Giraffe");
            pList.Add("Draw Kettle");
            pList.Add("Draw Pear");
            pList.Add("Draw Camel");
            pList.Add("Draw Carrot");
            pList.Add("Draw Bee");
            pList.Add("Draw Desk");
            pList.Add("Draw Beetle");

            //WRITE UNDER THIS
            pList.Add("Write Sailboat");
            pList.Add("Write Clock");
            pList.Add("Write Cow");
            pList.Add("Write Trumpet");
            pList.Add("Write Cherry");
            pList.Add("Write Coat");
            pList.Add("Write Wagon");
            pList.Add("Write Couch ");
            pList.Add("Write Caterpillar");
            pList.Add("Write Spoon");
            pList.Add("Write Monkey");
            pList.Add("Write Broom");
            pList.Add("Write Fork");
            pList.Add("Write Lips");
            pList.Add("Write Boot");
        }
    }

    public void Timer()
    {
    secondsCount += Time.deltaTime;
    bool newWord = false;
        if (secondsCount >= 20)
        {
            //Debug.Log("20 seconds passed");
            newWord = true;
            secondsCount = 0;
        }
        if (newWord == true)
        {
            PickWord(wordPool);
            newWord = false;
        }
    }

}
