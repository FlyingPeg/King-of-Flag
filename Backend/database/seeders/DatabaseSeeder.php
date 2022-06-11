<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\User;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        $user = User::create([
            'name' => 'FlyingPeg',
            'email' => '20520619@gm.uit.edu.vn',
            'password' => bcrypt('FnKL6upRv7uhvQ5Mj'),            
        ]);
    }
}
