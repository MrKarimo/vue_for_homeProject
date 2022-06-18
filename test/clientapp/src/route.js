import Home from "@/components/Home";
import weather from "@/components/Weather/route";
import institutionApplication from "@/components/institutionApplication/route";

const def = [
    {
        path: "",
        component: Home,
    },
];

const routes = def
    .concat(weather)
    .concat(institutionApplication)

export default routes;

