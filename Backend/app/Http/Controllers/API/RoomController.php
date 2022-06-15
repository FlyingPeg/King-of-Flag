<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Http\Controllers\API\BaseController as BaseController;
use App\Http\Resources\Room as RoomResource;
use App\Models\Room;
use Validator;
use Auth;
use DB;

class RoomController extends BaseController
{
    public function index()
    {   
        try{
            $rooms = Room::all();
            return $this->sendResponse(RoomResource::collection($rooms), 'Rooms fetched.');
        }catch(\Exception $e){
            return $this->sendError('Error.');
        } 
    }

    // Insert step into database
    public function store(Request $request)
    {
        $validator = Validator::make($request->all(),[
            'room_id' => 'required|string', 
        ]);

        if($validator->fails()){
            return $this->sendError('Create room failed.', ['error'=>'Check your input.']);   
        }
        $user = Auth::user(); 
        $room = Room::create([
            'user_id' => $user->id,
            'room_id' => $request->room_id,                         
            'step' => $request->step,             
        ]);           
        
        return $this->sendResponse(new RoomResource($room), 'Created room.');
    }

    public function show($room_id)
    {        
        $room_step = Room::where('room_id', $room_id)->get();  
        try{
            return $this->sendResponse(RoomResource::collection($room_step), 'Steps fetched.');
        }catch(\Exception $e){
            return $this->sendResponse([],'Steps fetched.');
        }
    }
}
