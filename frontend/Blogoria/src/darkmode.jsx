import { useContext } from "react"
import { ThemeContext } from "./themeContext.js"

function DarkMode() {
    const {theme, toggletheme } = useContext(ThemeContext)
      
    return (
        <>
            <div>
                <h1>Welcome, to our blog website</h1>
                <button onClick={toggletheme}>{theme === "Light" ? "Switch to dark mode" : "Click to change background "}</button>
                
            </div>
        </>
    )
}
export default DarkMode