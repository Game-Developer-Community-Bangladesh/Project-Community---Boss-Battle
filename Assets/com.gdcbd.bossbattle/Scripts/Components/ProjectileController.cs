using System;
using DG.Tweening;
using UnityEngine;

namespace com.gdcbd.bossbattle.components
{
    [CreateAssetMenu(fileName = "NewProjectileController", menuName = "BossBattle/ProjectileController")]
    public class ProjectileController : AbstractProjectileController
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _speed = 200f;
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeSpan = 2f;
       
        
       
        public override void Launch(ShootInfo shootInfo)
        {
            if (_projectilePrefab != null)
            {
                GameObject projectile = ObjectPoolManager.Instance.GetPooledObject(_projectilePrefab);
                if (projectile != null)
                {
                    projectile.transform.position = shootInfo.startTransform.position;
                    projectile.transform.rotation = shootInfo.startTransform.rotation;
                    projectile.SetActive(true);
                    // projectile.transform.parent = null;
                    ProjectileBehaviour pb = projectile.GetComponent<ProjectileBehaviour>(); // TODO : can get projectile behaviour to move projectile
                    if (pb != null)
                    {
                        pb.AddThrust(shootInfo.directon * _speed);
                       
                    }
                }
            }
        }
        
        
    }

    
   
    
}