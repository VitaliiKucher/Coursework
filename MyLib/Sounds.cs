using System.Media;

namespace MyLib
{
    public class Sounds
    {

        public void Hovering()//Відтворення звукового еффекту при наведенні на кнопку
        {
            SoundPlayer hovering = new SoundPlayer(@"C:\Users\admin\source\repos\КУРСОВА\SoundEffects\HoveringOverTheButton.wav");
            hovering.Play();
        }

        public void Press()//Відтворення звукового еффекту при натисканні на кнопку
        {
            SoundPlayer press = new SoundPlayer(@"C:\Users\admin\source\repos\КУРСОВА\SoundEffects\PressOnButton.wav");
            press.Play();
        }

        public void Invalid()//Відтворення звукового еффекту при неправильному введенні
        {
            SoundPlayer invalid = new SoundPlayer(@"C:\Users\admin\source\repos\КУРСОВА\SoundEffects\InvalidEnter.wav");
            invalid.Play();
        }

        public void Close()//Відтворення звукового еффекту при закритті форми
        {
            SoundPlayer close = new SoundPlayer(@"C:\Users\admin\source\repos\КУРСОВА\SoundEffects\CloseMenuButton.wav");
            close.Play();
        }
    }
}