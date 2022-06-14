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
            'user_w' => $user->id,             
            'room_id' => $request->room_id,
        ]);           
        
        return $this->sendResponse(new RoomResource($room), 'Created room.');
    }

    public function update(Request $request, $room_id)
    {
        $authUser = Auth::user();
        $room = Room::where('room_id', $room_id)->first();
            if (is_null($room)) {
                return $this->sendError('Room does not exist.');
            }
            $input = $request->all();
            $validator = Validator::make($input, [
                'user_b' => 'required|string',
            ]);
            if($validator->fails()){
                return $this->sendError($validator->errors());       
            }
            try{                      
                $room->user_b = $input['user_b'];
                $room->save();

                return $this->sendResponse(new RoomResource($room), 'Room updated.');
            }catch(\Exception $e){
                return $this->sendError('Permission denied.');
            }
    }
}
