using Contracts;
using UniRx;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Timer;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IEnemyHealth
    {
        // TODO: move to config
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject spawnOnDeath;

        public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;
        private IntReactiveProperty _currentHealth;


        
        private void Awake()
        {

            _currentHealth = new IntReactiveProperty(maxHealth);

            _currentHealth.Value *= (1 + 2 * (Mathf.FloorToInt(elapsedTime / 60)));
            
            _currentHealth.Where(hp => hp <= 0).Subscribe(_ =>
            {
                
                if (spawnOnDeath != null)
                    Instantiate(spawnOnDeath, transform.position, Quaternion.identity).SetActive(true);
                Destroy(gameObject);
            }).AddTo(this);

            
        }

        void IDamagable.DealDamage(int damage)
        {
            _currentHealth.Value -= damage;

            MessageBroker.Default.Publish(new EnemyDamageReceived
            {
                Damage = damage,
                WorldPosition = transform.position
            });
        }
    }
}