using GD.Selection;
using GD.Types;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

/// <summary>
/// Supports click to select and click to set waypoint on a mav mesh
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=CHV1ymlw-P8"/>
/// <seealso cref="https://www.youtube.com/watch?v=FkLJ45Pt-mY&t=158s"/>

namespace GD.Controllers
{
    public class CharacterNavigationController : MonoBehaviour
    {
        [Header("Selection & Waypoint")]
        [SerializeField]
        [Tooltip("Set the game object used to indicate that the character using this controller is currently selected.")]
        private GameObject selectionPrefab;

        [SerializeField]
        [Tooltip("Set the game object used to indicate a waypoint for the character using this controller for navigation.")]
        private GameObject waypointPrefab;

        [SerializeField]
        [Tooltip("Used by the waypoint when the character is moving. Can be simple empty object.")]
        private GameObject sceneAnchor;

        [Header("Selected Object Buffer")]
        [SerializeField]
        [Tooltip("A scriptable object which holds a reference to the currently selected character")]
        private GameObjectVariable currentlySelectedGameObject;

        private Animator animator;
        private NavMeshAgent navMeshAgent;
        private IRayProvider rayProvider;
        private ISelector selector;
        private RaycastHit hitInfo;
        private bool isSelected;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            rayProvider = GetComponent<IRayProvider>();
            selector = GetComponent<ISelector>();
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Called when a player selects the on-screen player avatar
        /// </summary>
        /// <param name="context"></param>
        public void OnSelectPlayer(InputAction.CallbackContext context)
        {
            //if player is selected and we click and select a different player
            if (currentlySelectedGameObject.Value != null
                && currentlySelectedGameObject.Value != gameObject)
            {
                //de-select current
                currentlySelectedGameObject.Value = null;
                SetSelected(false);
            }

            //set selected new player object
            SetSelected(true);
            currentlySelectedGameObject.Value = gameObject;
        }

        /// <summary>
        /// Called when player selects a destination point on the navmesh
        /// </summary>
        /// <param name="context"></param>
        public void OnSelectWaypoint(InputAction.CallbackContext context)
        {
            //if a player is selected then determine destination
            if (isSelected)
                ClickDestination();
        }

        /// <summary>
        /// Move selected player towards active destination point
        /// </summary>
        //private void Update()
        //{
        //    if (Vector3.Distance(navMeshAgent.destination, transform.position)
        //        <= navMeshAgent.stoppingDistance)
        //    {
        //        ClearWaypoint();
        //        animator.SetBool("IsWalking", false);
        //    }
        //}

        #region Actions -  Set/Clear destination and waypoint

        /// <summary>
        /// Sets navmesh target
        /// </summary>
        /// <param name="target"></param>
        private void SetDestination(Vector3 target)
        {
            navMeshAgent.SetDestination(target);
        }

        /// <summary>
        /// Tests if selector ray intersects with valid destination target
        /// </summary>
        private void ClickDestination()
        {
            selector.Check(rayProvider.CreateRay());
            if (selector.GetSelection() != null)
            {
                hitInfo = selector.GetHitInfo();
                SetDestination(hitInfo.point);
                SetWaypoint();
                SetSelected(false);
                animator.SetBool("IsWalking", true);
            }
        }

        /// <summary>
        /// Set the next naviagable waypoint
        /// </summary>
        private void SetWaypoint()
        {
            waypointPrefab.SetActive(true);
            waypointPrefab.transform.SetParent(sceneAnchor.transform);
            waypointPrefab.transform.position = navMeshAgent.destination;
        }

        /// <summary>
        /// Disable waypoint indicator and set waypoint transform back to attached player
        /// </summary>
        private void ClearWaypoint()
        {
            waypointPrefab.SetActive(false);
            waypointPrefab.transform.SetParent(transform);
        }

        /// <summary>
        /// Set selected and show selection indicator around the player
        /// </summary>
        /// <param name="isSelected"></param>
        public void SetSelected(bool isSelected)
        {
            this.isSelected = isSelected;
            selectionPrefab.SetActive(isSelected);
        }

        #endregion Actions -  Set/Clear destination and waypoint

        #region OLD INPUT - Selection

        private void OnMouseDown()
        {
            if (currentlySelectedGameObject.Value != null
                && currentlySelectedGameObject.Value != gameObject)
            {
                currentlySelectedGameObject.Value = null;
                SetSelected(false);
            }

            SetSelected(true);
            currentlySelectedGameObject.Value = gameObject;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1) && isSelected)
            {
                ClickDestination();
            }

            if (Vector3.Distance(navMeshAgent.destination, transform.position)
                <= navMeshAgent.stoppingDistance)
            {
                ClearWaypoint();
                animator.SetBool("IsWalking", false);
            }
        }

        #endregion OLD INPUT - Selection
    }
}