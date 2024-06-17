import { BrowserRouter, Route, Routes, } from "react-router-dom";
import Home from "../pages/home/Home";

const Router:React.FC=()=>{
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />}></Route>
            </Routes>
        </BrowserRouter>
    )
};

export default Router;