import { configureStore } from '@reduxjs/toolkit';
import MapReducer from '../Map/MapSlice'


export const store = configureStore({
  reducer: {
    map: MapReducer,
  },
});
