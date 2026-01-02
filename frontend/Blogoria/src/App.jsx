import { Link, Route, Routes } from "react-router"
import Home from "./Home"
import Blogs from "./Blog"
import About from "./About"
import Login from "./Login"
import Navbar from "./Navbar"



function App() {
  return (
    <>
      <Routes>
        <Route element={<Navbar />}>
          <Route path="/" element={<Home />} />
          <Route path="/blogs" element={<Blogs />} />
          <Route path="/about" element={<About />} />
        </Route>
        <Route path="/login" element={<Login />} />
      </Routes>
    </>
  )
}

export default App
