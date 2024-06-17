import { BrowserRouter, Route, Routes, } from "react-router-dom";
import Home from "../pages/home/Home";
import User1 from "../pages/user1/User1";
import User2 from "../pages/user2/User2";
import User3 from "../pages/user3/User3";

const Router:React.FC=()=>{
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />}></Route>
                <Route path="/user1" element={<User1 />}></Route>
                <Route path="/user2" element={<User2 />}></Route>
                <Route path="/user3" element={<User3 />}></Route>
            </Routes>
        </BrowserRouter>
    )
};

export default Router;