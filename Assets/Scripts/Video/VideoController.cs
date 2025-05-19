//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Video;

//public class VideoController : MonoBehaviour
//{
//    public Canvas videoCanvas; // el Canvas que contiene el RawImage
//    public RawImage rawImage;
//    public VideoPlayer videoPlayer;

//    public VideoClip video1;
//    public VideoClip video2;
//    public VideoClip video3;
//    public VideoClip video4;

//    public Button button1;
//    public Button button2;
//    public Button button3;
//    public Button button4;

//    private bool played1 = false;
//    private bool played2 = false;
//    private bool played3 = false;
//    private bool played4 = false;

//    private bool videoPlaying = false;

//    void Start()
//    {
//        videoCanvas.gameObject.SetActive(false); // desactiva el canvas al inicio

//        button1.onClick.AddListener(() => TryPlayVideo(video1, ref played1));
//        button2.onClick.AddListener(() => TryPlayVideo(video2, ref played2));
//        button3.onClick.AddListener(() => TryPlayVideo(video3, ref played3));
//        button4.onClick.AddListener(() => TryPlayVideo(video4, ref played4));

//        videoPlayer.loopPointReached += OnVideoEnd;
//    }

//    void Update()
//    {
//        if (videoPlaying && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
//        {
//            StopVideo();
//        }
//    }

//    void TryPlayVideo(VideoClip clip, ref bool hasPlayed)
//    {
//        if (hasPlayed) return;

//        hasPlayed = true;
//        videoCanvas.gameObject.SetActive(true); // activa el canvas
//        videoPlayer.clip = clip;
//        videoPlayer.Play();
//        videoPlaying = true;
//    }

//    void OnVideoEnd(VideoPlayer vp)
//    {
//        StopVideo();
//    }

//    void StopVideo()
//    {
//        videoPlayer.Stop();
//        videoCanvas.gameObject.SetActive(false); // desactiva el canvas
//        videoPlaying = false;
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public Canvas videoCanvas; // el Canvas que contiene el RawImage
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    public VideoClip videoInicio;  // video al iniciar
   // public VideoClip videoFin;     // video al terminar
    public VideoClip video1;
  //  public VideoClip video2;
   // public VideoClip video3;
   public VideoClip video4;

    public Button button1;
   // public Button button2;
  //  public Button button3;
   public Button button4;

    private bool played1 = false;
  //  private bool played2 = false;
    //private bool played3 = false;
   private bool played4 = false;

    private bool videoPlaying = false;

    void Start()
    {
        videoCanvas.gameObject.SetActive(false);

        button1.onClick.AddListener(() => TryPlayVideo(video1, ref played1));
        //button2.onClick.AddListener(() => TryPlayVideo(video2, ref played2));
      //  button3.onClick.AddListener(() => TryPlayVideo(video3, ref played3));
      button4.onClick.AddListener(() => TryPlayVideo(video4, ref played4));

        videoPlayer.loopPointReached += OnVideoEnd;

        //  Reproducir video de inicio
       PlayVideo(videoInicio);
    }

    void Update()
    {
        if (videoPlaying && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            StopVideo();
        }
    }

    void TryPlayVideo(VideoClip clip, ref bool hasPlayed)
    {
        if (hasPlayed) return;

        hasPlayed = true;
        PlayVideo(clip);
    }

    public void PlayVideo(VideoClip clip)
    {
        videoCanvas.gameObject.SetActive(true);
        videoPlayer.clip = clip;
        videoPlayer.Play();
        videoPlaying = true;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StopVideo();
    }

    void StopVideo()
    {
        videoPlayer.Stop();
        videoCanvas.gameObject.SetActive(false);
        videoPlaying = false;
    }

    //  Método público para llamar desde otro script (por ejemplo al finalizar el juego)
    /*public void ReproducirVideoFinal()
    {
        PlayVideo(videoFin);
    }*/
}
