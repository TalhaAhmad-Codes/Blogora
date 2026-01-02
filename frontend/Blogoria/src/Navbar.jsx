import { Link, NavLink, Outlet } from "react-router";
import './header.css'
function Navbar() {
    return (
        <>
        <div>
            <div className="header">
                <div>
                    <NavLink className="link"><h2>Blogoria</h2></NavLink>
                </div>
                <div>
                    <ul>
                        <li><NavLink className="link" to="/">Home</NavLink></li>
                        <li><NavLink className="link" to="/blogs">Blogs</NavLink></li>
                        <li><NavLink className="link" to="/about">About</NavLink></li>
                        <li><NavLink className="link" to="/login">Login</NavLink></li>
                    </ul>
                </div>
            </div>
            <Outlet/>
            </div>
        </>
    )
}
export default Navbar