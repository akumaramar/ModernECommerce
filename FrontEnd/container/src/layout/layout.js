import React from "react";
import Header from "./header";
import { BrowserRouter, Routes, Route, Outlet } from "react-router-dom";

const Layout = () => {
    return(
    <>
       <Header/>
        <main>
          <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
            {/* Replace with your content */}
            <Outlet/>
            {/* /End replace */}
          </div>
        </main>
    </>
    );    
}

export default Layout;