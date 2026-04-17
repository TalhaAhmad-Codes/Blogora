import {useEffect, useState } from "react"
import { ThemeContext } from "./themeContext.js"

export  function ThemeProvider({children}){
         const [theme,setTheme] = useState(()=>{
            return localStorage.getItem("theme") ||
            "light"
})
useEffect(()=>{
    document.body.className = theme;
    localStorage.setItem("theme",theme)
},[theme])
         const toggletheme=()=>{
       setTheme(prev => (prev ==="light" ? "dark" : "light"))
 }

// 2nd way for solving button text rendering problem

//  useEffect(()=>{
//     document.body.classList.remove("light","dark");
//     document.body .classList.add(theme)
//     localStorage.setItem("theme",theme)
//  },[theme])

//  const toggletheme =()=>{
//      setTheme(prev => (prev ==="light"? "dark": "light"))
//  }

    return(
        <>
        <ThemeContext.Provider value={{theme,toggletheme}}>
              {children}
        </ThemeContext.Provider>
        </>
    )
}