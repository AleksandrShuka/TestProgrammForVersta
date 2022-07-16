import { Orders } from "./components/Orders";
import { NewOrder } from "./components/NewOrder";

const AppRoutes = [
  {
    index: true,
    element: <NewOrder />
  },
  {
    path: '/orders',
    element: <Orders />
  }
];

export default AppRoutes;
