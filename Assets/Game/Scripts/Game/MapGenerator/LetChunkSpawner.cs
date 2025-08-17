using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace MapGenerator
{
    public class LetChunkSpawner : MonoBehaviour
    {
        #region Other Settings
        [SerializeField, Required, BoxGroup("Other Settings")] private Transform _player;
        #endregion
        #region Settings Pool
        [SerializeField, Required, BoxGroup("Settings Pool")] private Transform _startChunkSpawnPos;
        [SerializeField, Required, BoxGroup("Settings Pool")] private Transform _parentForChunks;
        [SerializeField, BoxGroup("Settings Pool"), Min(2)] private int _startPoolSize;
        [SerializeField, BoxGroup("Settings Pool")] private LetChunk[] _prefabChunks;
        #endregion
        private List<PoolObjects<LetChunk>> _poolList = new();
        private (LetChunk, int)[] _activeChunk = new (LetChunk, int)[2];

        private void Awake()
        {
            foreach (var prefabChunk in _prefabChunks)
                _poolList.Add(new PoolObjects<LetChunk>(prefabChunk, _parentForChunks, _startPoolSize));

            _activeChunk[0] = CreateChunk();
            _activeChunk[0].Item1.transform.position = _startChunkSpawnPos.position;
            _activeChunk[1] = CreateChunk();
            _activeChunk[1].Item1.transform.position = _activeChunk[0].Item1.end.position;
        }

        private void Update()
        {
            if (_player.position.y > _activeChunk[1].Item1.pivot.position.y)
                SpawnChunk();
        }

        private (LetChunk, int) CreateChunk()
        {
            int randChunk = Random.Range(0, _poolList.Count);
            LetChunk chunk = _poolList[randChunk].Get();
            return (chunk, randChunk);
        }

        private void SpawnChunk()
        {
            _poolList[_activeChunk[0].Item2].Realese(_activeChunk[0].Item1);
            _activeChunk[0] = _activeChunk[1];
            _activeChunk[1] = CreateChunk();
            _activeChunk[1].Item1.transform.position = _activeChunk[0].Item1.end.position;
        }

    }
}