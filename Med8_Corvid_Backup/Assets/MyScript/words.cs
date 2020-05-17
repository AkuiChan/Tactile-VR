using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

public class words : MonoBehaviour
{
    List<string> wordPool_1 = new List<string>();
    List<string> wordPool_2 = new List<string>();
    public Text txt, counter;
    //List<string> writePool = new List<string>();
    bool listEmpty, NextBool_1;
    public bool NextBool_2 = false;
    int CounterInt, nextInt;
    private float secondsCount;

    public GameObject button, procedualMesh1, procedualMesh2;
    public TargetCanvas _targetCanvas;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        int randNr = rand.Next(1,2);
        MakeLists(wordPool_1, randNr);

        if (randNr == 1)
        {
            MakeLists(wordPool_2, 2);
        }
        else
        {
            MakeLists(wordPool_2, 1);
        }

        txt = GameObject.Find("Word").GetComponent<Text>();
        CounterInt = 30;
        counter.text = CounterInt.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (NextBool_1 == true)
        {
            try
            {
                Timer(wordPool_1);
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                txt.text = "You are done with the first condition, with a table pressent in real life,\n" +
                    "please take the headset off and answer the questionnaire\n" +
                    "\n" +
                    "Click 'Start Condition' When you have Answered the questionnaire";
                listEmpty = true;
                NextBool_1 = false;
                button.SetActive(true);
            }
        }

        if (NextBool_2 == true)
        {
            try
            {
                Timer(wordPool_2);
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                txt.text = "Thank you for participanting \n" +
                    "You just finnished the seccond condition, with a virtual table" +
                    "Please answer the questionnaire one last time.";
                listEmpty = true;
                NextBool_2 = false;
            }
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

    public void Timer(List<string> ThisWordPool)
    {
        secondsCount += Time.deltaTime;
        bool newWord = false;
        if (secondsCount >= 25)
        {
            //Debug.Log("20 seconds passed");
            newWord = true;
            secondsCount = 0;

            CounterInt--;
            if (CounterInt <= 0)
            {
                CounterInt = 0;
            }
            counter.text = CounterInt.ToString();
        }
        if (newWord == true)
        {
            audioSource.Play(0);
            _targetCanvas.ResetCanvas();
            PickWord(ThisWordPool);
            newWord = false;
        }
    }

    public void NextCondition()
    {
        //Debug.Log("index " + nextInt);
        nextInt += 1;

        if (nextInt == 1)
        {
            txt.text = "Get Ready\n" +
                "You have 25 secconds for each word";
            CounterInt = 30;
            counter.text = CounterInt.ToString();
            NextBool_1 = true;
        }
        if (nextInt >= 2 && NextBool_1 == false && NextBool_2 == false)
        {
            procedualMesh1.SetActive(false); procedualMesh2.SetActive(true);
            txt.text = "Get Ready\n" +
                "You have 25 secconds for each word";
            CounterInt = 30;
            counter.text = CounterInt.ToString();
            NextBool_2 = true;
        }

        button.SetActive(false);
    }
}
