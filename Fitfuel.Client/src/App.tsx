import { Route, Routes } from "react-router-dom"
import LoginPage from "./pages/LoginPage/login.page"
import RegisterPage from "./pages/RegisterPage/register.page";
import UserIntroductionPage from "./pages/UserIntroductionPage/userIntroduction.page";
import HomePage from "./pages/HomePage/home.page";

import './scss/app.scss';

function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage/>}/>
      <Route path="/auth/login" element={<LoginPage/>}/>
      <Route path="/auth/register" element={<RegisterPage/>}/>
      <Route path="/auth/introduction" element={<UserIntroductionPage/>}/>
    </Routes>
  )
}

export default App
