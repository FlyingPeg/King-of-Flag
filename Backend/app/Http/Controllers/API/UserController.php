<?php


namespace App\Http\Controllers\API;

use App\Http\Controllers\API\BaseController as BaseController;
use App\Http\Resources\User as UserResource;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\User;
use Validator;
use Auth;
use DB;

class UserController extends BaseController
{
    public function index()
    {   
        try{
            $users = User::all()->sortByDesc("score");
            return $this->sendResponse(UserResource::collection($users), 'Users fetched.');
        }catch(\Exception $e){
            return $this->sendError('Error.');
        } 
    }

    public function profile(Request $request)
    {
        $user = Auth::user();
        return $this->sendResponse(new UserResource($user), 'User signed in.');
    }

    public function score(Request $request)
    {
        $user = Auth::user();
        if (is_null($user)) {
            return $this->sendError('User does not exist.');
        }
        $input = $request->all();
        $validator = Validator::make($input, [          
            'score' => 'required|integer',
        ]);
        if($validator->fails()){
            return $this->sendError($validator->errors());       
        }
        try{
            $user->score = $input['score'];           
            $user->save();

            return $this->sendResponse(new UserResource($user), 'Score updated.');
        }catch(\Exception $e){
            return $this->sendError('Error.');
        }
    }
}
