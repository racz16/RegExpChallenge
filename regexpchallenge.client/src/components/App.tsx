import { Link, NavLink, Outlet } from 'react-router-dom';

export default function App() {
    const navLinkClasses = 'link-light link-offset-2 link-underline-opacity-25 link-underline-opacity-100-hover';
    function getNavLinkClasses(isActive: boolean): string {
        if (isActive) {
            return navLinkClasses + ' link-underline-opacity-100';
        }
        return navLinkClasses;
    }
    return (
        <div className="d-flex flex-column">
            <header className="bg-success bg-gradient sticky-top">
                <nav className="container d-flex align-items-center gap-4">
                    <h1>
                        <Link className="text-decoration-none link-light" to="/">
                            RegExp Challenge
                        </Link>
                    </h1>
                    <NavLink to="/" className={({ isActive }) => getNavLinkClasses(isActive)}>
                        Challenges
                    </NavLink>
                    {/* <NavLink to="/create" className={({ isActive }) => getNavLinkClasses(isActive)}>
                        Create challenge
                    </NavLink> */}
                    <NavLink to="/useful-links" className={({ isActive }) => getNavLinkClasses(isActive)}>
                        Useful links
                    </NavLink>
                </nav>
            </header>
            <main>
                <div className="container">
                    <div className="row-12 my-4">
                        <Outlet />
                    </div>
                </div>
            </main>
        </div>
    );
}
