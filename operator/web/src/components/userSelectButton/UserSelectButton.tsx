import "./UserSelectButton.css"

const UserSelectButton:React.FC<{userIndex:number,isDHH:boolean}>=({userIndex,isDHH})=>{
    return(
        <div id="userSelectButton">
            <button>
                <h3>User {userIndex}</h3>
                <p>is DHH : {String(isDHH)}</p>
            </button>
        </div>
    )
};

export default UserSelectButton;