import { useState } from "react";
import "./login.css"
function Login() {
    const [islogin, setlogin] = useState(true);
    return (
        <>
            <div className="form-bg">
                <div className="container">
                    <div className="form-container">
                        <div className="form-toggle">
                            <button className={islogin ? 'active' : ""} onClick={() => setlogin(true)}>Login</button>
                            <button className={!islogin ? 'active' : ""} onClick={() => setlogin(false)}>Signup</button>
                        </div>
                        {
                            islogin ? <> <div className="form">
                                <h2>Login form</h2>
                                <input type="email" placeholder="Email" />
                                <input type="password" placeholder="Password" />
                                <a href="#">Forget Password</a>
                                <button>Login</button>
                                <p>Don't have an account? <a href="#" onClick={() => setlogin(false)}>Signup</a></p>
                            </div> </> : <> <div className="form">
                                <h2>Signup Form</h2>
                                <input type="email" placeholder="Email" />
                                <input type="password" placeholder="Password" />
                                <input type="password" placeholder="Confirm Password" />
                                <button>Signup Form</button>
                            </div> </>
                        }
                    </div>
                </div>
            </div>
        </>
    )
}
export default Login