using Content;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrap : MonoBehaviour
{
        [SerializeField] private CanvasView canvas;
        [FormerlySerializedAs("levelsDatabase")] [SerializeField] private Nnvjkernkjq nnvjkernkjq;
        [FormerlySerializedAs("soundManager")] [SerializeField] private BNjkewrkjhbvjhrt bNjkewrkjhbvjhrt;
        [FormerlySerializedAs("shopData")] [SerializeField] private Bnjkgnrjkweqw bnjkgnrjkweqw;

        private readonly Context _context = Context.Instance;

        private void Start()
        {
                Application.targetFrameRate = 60;
                
                DontDestroyOnLoad(this);
                
                _context.Register(canvas);
                _context.Register(nnvjkernkjq);
                _context.Register(new Bnjkwenrjkwe(nnvjkernkjq));
                _context.Register(bNjkewrkjhbvjhrt);
                _context.Register(bnjkgnrjkweqw);
                
                canvas.Bootstrap(_context);
                canvas.Load();
        }
}